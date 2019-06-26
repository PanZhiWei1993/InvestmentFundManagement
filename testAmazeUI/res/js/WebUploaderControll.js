var noticeFileUp = {};

$(function () {
    //noticeFileUp = WebUploader.create({
    //    swf: '@Url.Content("~/WebUploader/Uploader.swf")',
    //    // 文件接收服务端。
    //    server: '@Url.Content("/Upload/UpLoadProcess")',
    //    // 选择文件的按钮。可选。
    //    // 内部根据当前运行是创建，可能是input元素，也可能是flash.
    //    pick: '#uBtn_NoticeFile',
    //    formData: {
    //        UpType: "ProImg"
    //    },
    //});

    ////当有文件添加前触发，确保只有一条文件上传
    //noticeFileUp.on('beforeFileQueued', function (file) {
    //    // $list为容器jQuery实例
    //    noticeFileUp.reset();
    //});
    //// 当有文件添加进来后的时候
    //noticeFileUp.on('fileQueued', function (file) {
    //    // $list为容器jQuery实例
    //    $("#inp_upNoticeFileName").val(file.name);
    //});
    //// 文件上传过程中创建进度条实时显示。
    //noticeFileUp.on('uploadProgress', function (file, percentage) {

    //});
    //// 文件上传成功。
    //noticeFileUp.on('uploadSuccess', function (file, response) {              
    //    noticeFileModel.FileID = response.FileID;
    //});
    //// 文件上传失败，显示上传出错。
    //noticeFileUp.on('uploadError', function (file) {
    //    alert("上传失败，请重新添加");
    //    uploader.stop();
    //});
    //// 完成上传完了，成功或者失败，先删除进度条。
    //noticeFileUp.on('uploadComplete', function (file) {
    //    noticeFileUp.reset();
    //});
});
//export{noticeFileUp}