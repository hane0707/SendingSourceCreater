// 参考
// https://shimaji.exblog.jp/12891794/
// https://qiita.com/OXamarin/items/51c0d713910895a9ccba
// 参考（ファイル圧縮）
// https://takachan.hatenablog.com/entry/2017/12/25/040800

using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendingSourceCreater
{
    public partial class Form1 : Form
    {
        #region メンバ変数
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private bool _isExecute = false;
        #endregion

        #region 初期化処理
        /// <summary>
        /// 初期化処理
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            OriginDirectory.Text = ConfigurationManager.AppSettings["OriginFolderPath"];
            TargetDirectory.Text = ConfigurationManager.AppSettings["TargetFolderPath"];
            TargetDateFrom.Text = DateTime.Now.ToShortDateString();
            TargetDateTo.Text = DateTime.Now.ToShortDateString();
            GetZipFileCheck.Checked = true;
            UsePasswordCheck.Checked = true;
            Password.Enabled = true;
        }
        #endregion

        #region イベントハンドラ
        /// <summary>
        /// ファイル取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FileGetButton_Click(object sender, EventArgs e)
        {

            // 画面項目値の取得
            string originDirectory = OriginDirectory.Text;
            string targetDirectory = TargetDirectory.Text;

            string dateFrom = TargetDateFrom.Value.ToShortDateString().Replace("/", "");
            int dateFromYYYY = int.Parse(dateFrom.Substring(0, 4));
            int dateFromMM = int.Parse(dateFrom.Substring(4, 2));
            int dateFromDD = int.Parse(dateFrom.Substring(6, 2));
            DateTime targetDateFrom = new DateTime(dateFromYYYY, dateFromMM, dateFromDD, 0, 0, 0);

            string dateTo = TargetDateTo.Value.ToShortDateString().Replace("/", "");
            int dateToYYYY = int.Parse(dateTo.Substring(0, 4));
            int dateToMM = int.Parse(dateTo.Substring(4, 2));
            int dateToDD = int.Parse(dateTo.Substring(6, 2));
            DateTime targetDateTo = new DateTime(dateToYYYY, dateToMM, dateToDD, 0, 0, 0);

            bool zipFlg = GetZipFileCheck.Checked;
            bool usePasswordFlg = UsePasswordCheck.Checked;
            string password = Password.Text;

            // メッセージ初期化
            ClearMsg();

            // 実行前エラーチェック
            if (!CheckExecute(originDirectory
                                , targetDirectory
                                , targetDateFrom
                                , targetDateTo
                                , zipFlg
                                , usePasswordFlg
                                , password))
            {
                MsgLabel.Text = "指定された条件に入力ミスがあります。";
                MsgLabel.Visible = true;
                MsgLabel.ForeColor = Color.OrangeRed;

                return;
            }

            try
            {
                // 実行中にもう一度押されたらタスクのキャンセルを行う
                if (_isExecute)
                {
                    _isExecute = false;
                    _cancellationTokenSource.Cancel();
                    return;
                }

                // メンバ変数更新
                _isExecute = true;
                _cancellationTokenSource = new CancellationTokenSource();
                _cancellationToken = _cancellationTokenSource.Token;

                // ファイルコピー実行処理
                await Task.Run(() =>
                {
                    CopyFileWithDirectory(originDirectory
                                            , targetDirectory
                                            , targetDateFrom
                                            , targetDateTo);
                }, _cancellationToken);

                // エラーがある場合は圧縮しない
                if (!string.IsNullOrEmpty(ErrorMsgLabel.Text))
                    return;

                // 圧縮処理
                if (zipFlg)
                {
                    string targetZipDirectory = targetDirectory.Substring(0, targetDirectory.LastIndexOf(@"\") + 1)
                                                    + @"送付ソース\" + DateTime.Today.ToShortDateString().Replace("/", "");

                    if (!Directory.Exists(targetZipDirectory))
                        Directory.CreateDirectory(targetZipDirectory);

                    // ziplibを使用
                    ICSharpCode.SharpZipLib.Zip.FastZip fastZip = new ICSharpCode.SharpZipLib.Zip.FastZip();
                    fastZip.CreateEmptyDirectories = true;

                    if (usePasswordFlg)
                        fastZip.Password = Password.Text;

                    string dateNow = DateTime.Now.ToShortDateString().Replace("/", "");
                    fastZip.CreateZip(targetZipDirectory + @"\source_" + dateNow + ".zip", targetDirectory, true, null, null);
                }

            }
            catch (Exception ex)
            {
                SetErrMsg(ex.Message);
            }
            finally
            {
                // 結果セット
                label4.Text = string.Empty;
                if (!_isExecute)
                {
                    // 処理キャンセル
                    MsgLabel.Text = "処理が取り消されました。";
                    MsgLabel.Visible = true;
                    MsgLabel.ForeColor = Color.Yellow;
                }
                else if (!string.IsNullOrEmpty(ErrorMsgLabel.Text))
                {
                    // 処理終了（エラーあり）
                    MsgLabel.Text = "処理終了。一部の処理に失敗しました。";
                    MsgLabel.Visible = true;
                    MsgLabel.ForeColor = Color.OrangeRed;
                }
                else
                {
                    // 処理終了（エラーなし）
                    MsgLabel.Text = "処理正常終了。";
                    MsgLabel.Visible = true;
                    MsgLabel.ForeColor = Color.RoyalBlue;
                }

                _isExecute = false;
                _cancellationTokenSource.Dispose();
            }
        }

        /// <summary>
        /// 取得元フォルダ検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OriginDirectoryGetButton_Click(object sender, EventArgs e)
        {
            TextBox txtbox = OriginDirectory;
            ShowFolderDialog(txtbox);
        }

        /// <summary>
        /// 保存先フォルダ検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TargetDirectoryGetButton_Click(object sender, EventArgs e)
        {
            TextBox txtbox = TargetDirectory;
            ShowFolderDialog(txtbox);
        }

        /// <summary>
        /// 「ファイルコピー後に圧縮する」チェックのチェンジイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetZipFileCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (GetZipFileCheck.Checked == true)
            {
                UsePasswordCheck.Enabled = true;
            }
            else
            {
                UsePasswordCheck.Checked = false;
                UsePasswordCheck.Enabled = false;
                Password.Text = string.Empty;
                Password.Enabled = false;
            }
        }

        /// <summary>
        /// 「パスワード」使用有無チェックのチェンジイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsePasswordCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (UsePasswordCheck.Checked == true)
            {
                Password.Enabled = true;
            }
            else
            {
                Password.Text = string.Empty;
                Password.Enabled = false;
            }
        }

        #endregion

        #region ボタン押下時処理
        /// <summary>
        /// ダイアログを表示し、フォルダを選択する
        /// </summary>
        /// <param name="txtbox">戻り値格納先TextBox</param>
        private void ShowFolderDialog(TextBox txtbox)
        {
            // FolderBrowserDialogクラスのインスタンス生成
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            // ダイアログタイトルの設定
            fbd.Description = "フォルダを選択してください";
            // ルートフォルダの設定
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            // 初期選択されているフォルダの設定
            fbd.SelectedPath = @"c:\";

            //ダイアログを表示する
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                // 選択したフォルダ名を取得
                txtbox.Text = fbd.SelectedPath;
            }
        }

        /// <summary>
        /// ディレクトリ構成を含め、再帰的に対象ファイルをコピーする
        /// </summary>
        /// <param name="originDirectory">取得元フォルダ</param>
        /// <param name="targetDirectory">保存先フォルダ</param>
        /// <param name="targetDateFrom">取得ファイル更新日付（From）</param>
        /// <param name="targetDateTo">取得ファイル更新日付（To）</param>
        private void CopyFileWithDirectory(string originDirectory
                                            , string targetDirectory
                                            , DateTime targetDateFrom
                                            , DateTime targetDateTo)
        {
            // 保存先のディレクトリ名の末尾に"\"をつける
            if (targetDirectory[targetDirectory.Length - 1] != Path.DirectorySeparatorChar)
                targetDirectory = targetDirectory + Path.DirectorySeparatorChar;

            try
            {
                // タスクのキャンセルがされていたら例外を投げる
                _cancellationToken.ThrowIfCancellationRequested();

                // 取得元ディレクトリ配下のファイルを検索し、条件に一致するファイルを取得する
                string[] files = Directory.GetFiles(originDirectory);
                foreach (string file in files)
                {
                    // 処理中のディレクトリを画面に表示
                    Invoke(new Action<string>(SetExecuteMsg), file);

                    if (!CheckTargetFile(file, targetDateFrom, targetDateTo))
                        continue;

                    // 保存先のディレクトリがないときは作る（属性もコピー）
                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                        File.SetAttributes(targetDirectory, File.GetAttributes(originDirectory));
                    }

                    File.Copy(file, targetDirectory + Path.GetFileName(file), true);
                }

                // 取得元ディレクトリ配下のディレクトリについて、再帰的に呼び出す
                string[] dirs = Directory.GetDirectories(originDirectory);
                foreach (string dir in dirs)
                {
                    if (!CheckTargetFolder(dir))
                        continue;

                    CopyFileWithDirectory(dir
                                            , targetDirectory + Path.GetFileName(dir)
                                            , targetDateFrom
                                            , targetDateTo);
                }

            }
            catch (UnauthorizedAccessException ex)
            {
                string[] msg = ex.Message.Split('\'');

                Invoke(new Action<string>(SetErrMsg), "権限エラー：" + msg[1]);
            }
            catch (OperationCanceledException)
            {
                // 処理なし
                // 処理キャンセルのメッセージは呼び出し元でセットする
            }
            catch (Exception ex)
            {
                Invoke(new Action<string>(SetErrMsg), ex.Message);
            }
        }
        #endregion

        #region チェック処理
        /// <summary>
        /// 実行前エラーチェック
        /// </summary>
        /// <param name="originDirectory">取得元フォルダ</param>
        /// <param name="targetDirectory">保存先フォルダ</param>
        /// <param name="targetDateFrom">取得ファイル更新日付（From）</param>
        /// <param name="targetDateTo">取得ファイル更新日付（To）</param>
        /// <returns></returns>
        private bool CheckExecute(string originDirectory
                                    , string targetDirectory
                                    , DateTime targetDateFrom
                                    , DateTime targetDateTo
                                    , bool zipFlg
                                    , bool usePasswordFlg
                                    , string password)
        {            
            // ディレクトリの入力チェック
            if (string.IsNullOrEmpty(originDirectory)
                || string.IsNullOrEmpty(targetDirectory))
                SetErrMsg("取得元フォルダと保存先フォルダは必須入力項目です。");

            // 取得元ディレクトリの存在チェック
            if (!(Directory.Exists(originDirectory)))
                SetErrMsg("指定された取得元フォルダが存在しません。");

            // 取得元ディレクトリの使用可否チェック
            if (!CheckTargetFolder(originDirectory))
                SetErrMsg("指定された取得元フォルダは使用できません。");

            // 保存元ディレクトリの存在チェック
            if (!(Directory.Exists(targetDirectory)))
                SetErrMsg("指定された保存先フォルダが存在しません。");

            // 保存先ディレクトリの使用可否チェック
            if (!CheckTargetFolder(targetDirectory))
                SetErrMsg("指定された保存先フォルダは使用できません。");

            // 日付のFrom～toチェック
            if (targetDateFrom.Date > targetDateTo.Date)
                SetErrMsg("日付はFrom ≦ Toで入力してください。");

            // パスワード入力チェック
            if (zipFlg && usePasswordFlg && string.IsNullOrEmpty(password))
                SetErrMsg("パスワードを入力してください。");

            return string.IsNullOrEmpty(ErrorMsgLabel.Text) ? true : false;
        }

        /// <summary>
        /// ファイルの取得判定
        /// </summary>
        /// <param name="file"></param>
        /// <param name="targetDateFrom">取得ファイル更新日付（From）</param>
        /// <param name="targetDateTo">取得ファイル更新日付（To）</param>
        /// <returns></returns>
        private static bool CheckTargetFile(string file, DateTime targetDateFrom, DateTime targetDateTo)
        {
            // 存在チェック
            if (!File.Exists(file))
                return false;

            // 属性チェック
            // 非表示、システムフォルダは除外
            FileAttributes attributes = File.GetAttributes(file);
            if ((attributes & FileAttributes.System) == FileAttributes.System
                || (attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                return false;

            // 対象日付範囲チェック
            DateTime lastWriteDateTime = File.GetLastWriteTime(file);
            if (lastWriteDateTime.Date < targetDateFrom.Date || targetDateTo.Date < lastWriteDateTime.Date)
                return false;

            return true;
        }

        /// <summary>
        /// フォルダの対象判定
        /// </summary>
        /// <param name="dir">取得元フォルダ</param>
        /// <returns></returns>
        private static bool CheckTargetFolder(string dir)
        {
            string[] arr = dir.Split('\\');
            string strLastDir = arr[arr.Length - 1];

            // 非表示、システムフォルダは除外
            FileAttributes attributes = File.GetAttributes(dir);
            if ((attributes & FileAttributes.System) == FileAttributes.System
                || (attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                return false;

            // 特定フォルダ名は除外
            if (strLastDir == "bin"
                || strLastDir == "obj"
                || strLastDir == "Program Files"
                || strLastDir == "Program Files (x86)"
                || strLastDir == "Windows")
                return false;

            return true;
        }
        #endregion

        #region メッセージセット（UI側スレッドで処理させる用）
        /// <summary>
        /// 実行中メッセージのセット
        /// </summary>
        /// <param name="file">処理中のディレクトリ</param>
        public void SetExecuteMsg(string file)
        {
            label4.Text = "処理中...  " + file;
        }

        /// <summary>
        /// エラーメッセージのセット
        /// </summary>
        /// <param name="msg">エラーメッセージ</param>
        public void SetErrMsg(string msg)
        {
            ErrorMsgLabel.Text += msg + Environment.NewLine;
        }

        /// <summary>
        /// メッセージ初期化
        /// </summary>
        private void ClearMsg()
        {
            MsgLabel.Text = string.Empty;
            ErrorMsgLabel.Text = string.Empty;
        }
        #endregion
    }
}