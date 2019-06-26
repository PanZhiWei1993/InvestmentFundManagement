$(function () {
    //初始化分页列表
    $.defaultsPage = {
        ID: "",
        PageIndex: 1,
        PageSize: 10,
        PageStar: 1,
        PageCount: 5,
        DataCount: 0,
        ClickFun: ""
    };
    //获取分页代码
    var GetPageHtml = function (options) {
       
        var pageStar = options.PageStar;
        var pageIndex = options.PageIndex;
        //获取总页数
        var allPageNum = 1;
        if (options.DataCount >= options.PageSize) {
            //向上取整，有余数加1
            allPageNum = Math.ceil(options.DataCount / options.PageSize);
            //if (options.DataCount % options.PageSize > 0) {
            //    allPageNum ++;
            //}
        }
        //获取画出页数   
        var pageCount = options.PageCount;
        //计算有没有多余的页数
        var caPageCount = options.PageCount + pageStar - (allPageNum + 1) <= 0;
        //如果没有有多余页数
        if (!caPageCount) {
            pageCount = allPageNum + 1 - options.PageStar;
        }

        //获取前翻时的参数
        options.PageStar = pageStar - options.PageCount <= 0 ? pageStar : pageStar - options.PageCount;
        var aheadPageOpt = JSON.stringify(options);
        options.PageStar = pageStar;

        //获取后翻页时的参数
        options.PageStar = caPageCount ? (pageStar + pageCount) : pageStar;
        var behPageOpt = JSON.stringify(options);
        options.PageStar = pageStar;

        //分页列表html
        var pageHtml = "<div class=\"am-fr\">";
        pageHtml += " <ul class=\"am-pagination tpl-pagination\">";
        pageHtml += "<li><a href=javascript:$.BindPageList(" + aheadPageOpt + ")>«</a></li>";
        for (var i = 0; i < pageCount; i++) {
            var nowPage = i + pageStar;
            options.PageIndex = nowPage;
            if (nowPage == pageIndex) {
                pageHtml += "<li class=\"am-active\"><a href=javascript:" + options.ClickFun + "(" + JSON.stringify(options) + ") >" + nowPage + "</a></li>";
            } else {
                pageHtml += "<li><a href=javascript:" + options.ClickFun + "(" + JSON.stringify(options) + ") >" + nowPage + "</a></li>";
            }
        }
        pageHtml += "<li><a href=javascript:$.BindPageList(" + behPageOpt + ")>»</a></li>";
        pageHtml += " </ul> </div >";
        return pageHtml;
    };
    $.BindPageList = function (options) {
        var defaults = {
            ID: "",
            PageIndex: 1,
            PageSize: 1,
            PageStar: 1,
            PageCount: 5,
            DataCount: 0,
            ClickFun: ""
        };
        var opts = $.extend(defaults, options);
        if (opts.ID != "") {
            $("#" + opts.ID).html(GetPageHtml(opts));
        }

    };

});