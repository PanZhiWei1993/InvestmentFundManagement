
/*
 封装ajax方法，便于自己使用
 by 潘志伟 2018-05-23
 */

$(function ($) {
    $.myUrl = "";//默认路径

    $.ajaxGet = function (options) {
        $.ajaxExpand(options);
    };
    $.ajaxAsyncGet = function (options) {
        options.async = true;
        $.ajaxExpand(options);
    };
    $.ajaxPost = function (options) {    
        options.type = "Post";
        $.ajaxExpand(options);
    },
    $.ajaxAsyncPost = function (options) {
            options.async = true;
            $.ajaxPost(options);
        },
    $.ajaxAction = function (options) {
        var defaults = {
            type: "Post",
            async: false,//(默认: true) 默认设置下，所有请求均为异步请求。如果需要发送同步请求，请将此选项设置为 false。注意，同步请求将锁住浏览器，用户其它操作必须等待请求完成才可以执行。
            cache: false,//(默认: false,dataType为script和jsonp时默认为false) jQuery 1.2 新功能，设置为 false 将不缓存此页面。
            contentType: "application/x-www-form-urlencoded",
            data: {},
            url: "",
            loading: false, //是否启用预加载特效
            dataType: "json",
            headers: {},
            success: function () { },
            error: function () { }
        };
        var opts = $.extend(defaults, options);
        if (opts.loading)
            $.ajaxExpand.loading();
        $.ajax({
            type: opts.type,
            async: opts.async,
            cache: opts.cache,
            contentType: opts.contentType,
            headers: opts.headers,
            data: opts.data,
            //dataType: opts.dataType,
            url: $.myUrl + opts.url,
            success: function (result) {             
                opts.success(result);              
                if (opts.loading)
                    $.ajaxExpand.loadClose();
            },
            error: function (er) {
                opts.error(er);
                if (opts.loading)
                    $.ajaxExpand.loadClose();
            }
        });

    },
    //jquery.ajaxGet 拓展函数
    $.ajaxExpand = function (options) {
        var defaults = {
            type: "Get",
            async: false,//(默认: true) 默认设置下，所有请求均为异步请求。如果需要发送同步请求，请将此选项设置为 false。注意，同步请求将锁住浏览器，用户其它操作必须等待请求完成才可以执行。
            cache: false,//(默认: false,dataType为script和jsonp时默认为false) jQuery 1.2 新功能，设置为 false 将不缓存此页面。
            contentType: "application/x-www-form-urlencoded",
            data: {},
            url: "",
            loading: false, //是否启用预加载特效
            dataType: "json",
            headers: {},
            success: function () { },
            error: function () { }
        };
        var opts = $.extend(defaults, options);
        if (opts.loading) $.ajaxExpand.loading();
        $.ajax({
            type: opts.type,
            async: opts.async,
            cache: opts.cache,
            contentType: opts.contentType,
            headers: opts.headers,
            data: opts.data,
            //dataType: opts.dataType,
            url: $.myUrl + opts.url,
            success: function (result) {
                if (typeof (result.ResultCode) === "undefined") {
                    //$.ajaxExpand.loadClose();
                    alert("系统错误,发生了不在预料中的错误！");
                }
                else if (result.ResultCode === 1) {
                    opts.success(result.ResultData);
                }
                else {
                    //$.ajaxExpand.loadClose();
                    alert(result.ResultMsg);
                }               
                if (opts.loading)
                    $.ajaxExpand.loadClose();
            },
            error: function (er) {
                opts.error(er);
                if (opts.loading)
                    $.ajaxExpand.loadClose();
            }
        });
        };
    $.SetTableHtml = function (option) {       
        _TableHelper.data = option.data;
        $.ajax({
            type: "POST",
            url: option.url,
            data: _TableHelper.data,
            datatype: "json",
            success: function (data) {
                $('#' + option.id).html(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }

        });
    }

  
});