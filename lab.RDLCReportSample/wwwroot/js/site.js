var AppSlimSelect = function () {


    var _init = function (ddlInputId) {
        _generatorSlimSelect(ddlInputId, false);
    };

    var _initByClass = function (ddlInputId) {
        _generatorSlimSelect(ddlInputId, true);
    };

    var _generatorSlimSelect = function (ddlInputId, isClass) {

        var ddlInputEle = ('#' + ddlInputId);

        if (isClass) { ddlInputEle = ('.' + ddlInputId) }

        var ddlSlimSelect = new SlimSelect({
            select: ddlInputEle,
            settings: {
                placeholderText: '-- Select One --', allowDeselect: true
            }
        });

        //$(ddlInputEle).css({ "display": "block", "position": "fixed", "width": "1px", "left": "-100px" });

    };

    var _initMulti = function (ddlInputId) {
        _generatorSlimSelectMulti(ddlInputId, false);
    };

    var _initMultiByClass = function (ddlInputId) {
        _generatorSlimSelectMulti(ddlInputId, true);
    };

    var _generatorSlimSelectMulti = function (ddlInputId, isClass) {

        var ddlInputEle = ('#' + ddlInputId);

        if (isClass) { ddlInputEle = ('.' + ddlInputId) }

        var ddlSlimSelect = new SlimSelect({
            select: ddlInputEle,
            settings: {
                placeholderText: '-- Select Multipule --', allowDeselect: true
            }
        });

        //$(ddlInputEle).css({ "display": "block", "position": "fixed", "width": "1px", "left": "-100px" });

    };

    return {
        Init: _init,
        InitByClass: _initByClass,

        InitMulti: _initMulti,
        InitMultiByClass: _initMultiByClass
    };
}();