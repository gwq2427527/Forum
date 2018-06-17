// 需引用 jQuery 
// 2017-02-04 有修改过

(function () {

    var zjValidator = (function () {
        return {
            // 是否匹配
            isMatch: function (exp, txt) {
                return new RegExp(exp).test(txt);
            },
            // 手机号码
            isMobile: function (txt) {
                return zjValidator.isMatch("^1\\d{10}$", txt);
                //return util.expVal( "^(((13[0-9]{1})|151|153|158|159)+\\d{8})$", txt );
            },
            // 固话号码
            isTelePhone: function (txt) {
                return zjValidator.isMatch("^\\d{3,4}-?\\d{7,8}$", txt);
            },
            isEmail: function (txt) {
                return zjValidator.isMatch("^\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$", txt);
            },
            // 身份证
            isIdCard: function (txt) {
                return zjValidator.isMatch("(^[0-9]{17}([0-9]|X|x)$)|(^[0-9]{15}$)", txt);
            },
            // 邮编
            isZip: function (txt) {
                return zjValidator.isMatch("^\\d{6}$", txt);
            },
            isUserName: function (txt) {
                return zjValidator.isMatch("^[a-zA-Z0-9]{3,20}$", txt);
            },
            // 真实姓名
            isRealName: function (txt) {
                return zjValidator.isMatch("^[\u4e00-\u9fa5]{2,10}$", txt);
            },
            // 正整数（包括0）
            isPInteger: function (txt) {
                return zjValidator.isMatch("^[0-9]+$", txt);
            },
            // 正数（包括0和小数）
            isPositive: function (txt) {
                return zjValidator.isNumber(txt) && Number(txt) >= 0;
            },
            // 数字（包括负数和小数）
            isNumber: function (txt) {
                return txt != null && txt.length > 0 && !(/\s/.test(txt)) && !isNaN(txt);
            },
            // 日期 yyyy-MM-dd
            isDate: function (txt) {
                return zjValidator.isMatch("^((([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29))$", txt);
            },
            // 时间 HH:mm:ss , mm和ss可无
            isTime: function (txt) {
                if (zjValidator.isMatch("^\\d{1,2}(:\\d{1,2}(:\\d{1,2})?)?$", txt)) {
                    var h, m, s, arr = txt.split(':');
                    h = parseInt(arr[0]);
                    if (h >= 0 && h < 24) {
                        if (arr.length > 1) {
                            m = parseInt(arr[1]);
                            if (m >= 0 && m < 60) {
                                if (arr.length > 2) {
                                    s = parseInt(arr[2]);
                                    return s >= 0 && s < 60;
                                } else return true;
                            }
                        } else return true;
                    }
                }
                return false;
            },
            // 日期和时间 yyyy-MM-dd HH:mm:ss , mm和ss可无
            isDateTime: function (txt) {
                var arr = txt.split(' ');
                if (arr.length == 1) return zjValidator.isDate(arr[0]);
                if (arr.length == 2) return zjValidator.isDate(arr[0]) && zjValidator.isTime(arr[1]);
                return false;
            },
            isQQ: function (txt) {
                return zjValidator.isMatch("^[1-9]\\d{4,11}$", txt);
            },
            isIp: function (txt) {
                return zjValidator.isMatch("^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$", txt);
            },
            // 网址
            isUrl: function (txt) {
                return zjValidator.isMatch("^http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?$", txt);
            },
            // 图片扩展名
            isImageExtension: function (imgPath) {
                var index = imgPath.lastIndexOf(".");
                if (index < 0 || index == imgPath.length - 1) return false;
                var expandName = imgPath.substring(index + 1).toLowerCase();
                var arr = ",gif,jpg,jpeg,jpe,bmp,ico,png,";
                return arr.indexOf("," + expandName + ",") > -1;
            }
        };
    }());

    window.zjValidator = window.zjV = zjValidator;


    // validateCallBack : function (isOk, validator) { } , 可为 null
    var zjValidatorHandler = function (validateCallBack) {

        var BaseValidator = function (input, errMsg, isEmptyable, tag) {
            this.input = input;
            this.errMsg = errMsg;
            this.isEmptyable = isEmptyable;
            this.tag = tag;
            if (isEmptyable != null) {
                if (isEmptyable !== true && isEmptyable !== false) {
                    this.isEmptyable = false;
                    this.tag = isEmptyable;
                }
            } else this.isEmptyable = false;
            this.validate = function () {
                throw new Error("未实现验证方法：validate");
            };
        };

        var NotEmptyValidator = function (input, errMsg, tag) {
            BaseValidator.call(this, input, errMsg, false, tag);
            this.validate = function () {
                return $.trim($(this.input).val()).length > 0;
            };
        };

        var EqualValidator = function (input, toInput, errMsg, isEmptyable, tag) {
            BaseValidator.call(this, input, errMsg, isEmptyable, tag);
            this.toInput = toInput;
            this.validate = function () {
                if (!this.isEmptyable && $(this.input).val().length == 0) return false;
                return $(this.input).val() == $(this.toInput).val();
            };
        };

        var SelectValidator = function (input, minIndex, errMsg, tag) {
            BaseValidator.call(this, input, errMsg, false, tag);
            this.minIndex = minIndex;
            this.validate = function () {
                return $(this.input)[0].selectedIndex >= this.minIndex;
            };
        };

        var MinLenValidator = function (input, minLength, errMsg, isEmptyable, tag) {
            BaseValidator.call(this, input, errMsg, isEmptyable, tag);
            this.minLength = minLength;
            this.validate = function () {
                var l = $(this.input).val().length;
                if (this.isEmptyable && l == 0) return true;
                return l >= this.minLength;
            };
        };

        var MaxLenValidator = function (input, maxLength, errMsg, isEmptyable, tag) {
            BaseValidator.call(this, input, errMsg, isEmptyable, tag);
            this.maxLength = maxLength;
            this.validate = function () {
                var l = $(this.input).val().length;
                if (this.isEmptyable && l == 0) return true;
                return l <= this.maxLength;
            };
        };

        var RangeLenValidator = function (input, minLength, maxLength, errMsg, isEmptyable, tag) {
            BaseValidator.call(this, input, errMsg, isEmptyable, tag);
            this.minLength = minLength;
            this.maxLength = maxLength;
            this.validate = function () {
                var l = $(this.input).val().length;
                if (this.isEmptyable && l == 0) return true;
                return l >= this.minLength && l <= this.maxLength;
            };
        };

        var MinValueValidator = function (input, minValue, errMsg, isEmptyable, tag) {
            BaseValidator.call(this, input, errMsg, isEmptyable, tag);
            this.minValue = minValue;
            this.validate = function () {
                var v = $(this.input).val();
                if (this.isEmptyable && v.length == 0) return true;
                return !isNaN(v) && Number(v) >= this.minValue;
            };
        };

        var MaxValueValidator = function (input, maxValue, errMsg, isEmptyable, tag) {
            BaseValidator.call(this, input, errMsg, isEmptyable, tag);
            this.maxValue = maxValue;
            this.validate = function () {
                var v = $(this.input).val();
                if (this.isEmptyable && v.length == 0) return true;
                return !isNaN(v) && Number(v) <= this.maxValue;
            };
        };

        var RangeValueValidator = function (input, minValue, maxValue, errMsg, isEmptyable, tag) {
            BaseValidator.call(this, input, errMsg, isEmptyable, tag);
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.validate = function () {
                var v = $(this.input).val();
                if (this.isEmptyable && v.length == 0) return true;
                if (isNaN(v)) return false;
                var vN = Number(v);
                return vN >= this.minValue && vN <= this.maxValue;
            };
        };

        var RegexValidator = function (input, pattern, errMsg, isEmptyable, tag) {
            BaseValidator.call(this, input, errMsg, isEmptyable, tag);
            this.pattern = pattern;
            this.validate = function () {
                var v = $(this.input).val();
                if (this.isEmptyable && v.length == 0) return true;
                return zjValidator.isMatch(this.pattern, v);
            };
        };

        var FunValidator = function (input, validateFun, errMsg, isEmptyable, tag) {
            BaseValidator.call(this, input, errMsg, isEmptyable, tag);
            this.validateFun = validateFun;
            this.validate = function () {
                var v = $(this.input).val();
                if (this.isEmptyable && v.length == 0) return true;
                return this.validateFun(v);
            };
        };

        var CustomValidator = function (input, validate, errMsg, tag) {
            BaseValidator.call(this, input, errMsg, tag);
            this.validate = validate;
        };

        var _list = [];

        this.add = function (validator) {
            _list.push(validator);
            return _list[_list.length - 1];
        };
        // 添加并返回不能为空验证
        this.addNotEmptyValidator = function (input, errMsg, tag) {
            return this.add(new NotEmptyValidator(input, errMsg, tag));
        };
        // 添加并返回值必须相等验证
        this.addEqualValidator = function (input, toInput, errMsg, isEmptyable, tag) {
            return this.add(new EqualValidator(input, toInput, errMsg, isEmptyable, tag));
        };
        // 添加并返回下拉列表最小选择索引验证
        this.addSelectValidator = function (input, minIndex, errMsg, tag) {
            return this.add(new SelectValidator(input, minIndex, errMsg, tag));
        };
        // 添加并返回最小长度验证
        this.addMinLenValidator = function (input, minLength, errMsg, isEmptyable, tag) {
            return this.add(new MinLenValidator(input, minLength, errMsg, isEmptyable, tag));
        };
        // 添加并返回最大长度验证
        this.addMaxLenValidator = function (input, maxLength, errMsg, isEmptyable, tag) {
            return this.add(new MaxLenValidator(input, maxLength, errMsg, isEmptyable, tag));
        };
        // 添加并返回长度必须介于 minLength 和 maxLength 之间的验证
        this.addRangeLenValidator = function (input, minLength, maxLength, errMsg, isEmptyable, tag) {
            return this.add(new RangeLenValidator(input, minLength, maxLength, errMsg, isEmptyable, tag));
        };
        // 添加并返回最小值验证
        this.addMinValueValidator = function (input, minValue, errMsg, isEmptyable, tag) {
            return this.add(new MinValueValidator(input, minValue, errMsg, isEmptyable, tag));
        };
        // 添加并返回最大值验证
        this.addMaxValueValidator = function (input, maxValue, errMsg, isEmptyable, tag) {
            return this.add(new MaxValueValidator(input, maxValue, errMsg, isEmptyable, tag));
        };
        // 添加并返回值必须介于 minValue 和 maxValue 之间的验证
        this.addRangeValueValidator = function (input, minValue, maxValue, errMsg, isEmptyable, tag) {
            return this.add(new RangeValueValidator(input, minValue, maxValue, errMsg, isEmptyable, tag));
        };
        // 添加并返回正则表达式验证
        this.addRegexValidator = function (input, pattern, errMsg, isEmptyable, tag) {
            return this.add(new RegexValidator(input, pattern, errMsg, isEmptyable, tag));
        };
        // 添加并返回方法验证
        this.addFunValidator = function (input, validateFun, errMsg, isEmptyable, tag) {
            return this.add(new FunValidator(input, validateFun, errMsg, isEmptyable, tag));
        };
        // 添加并返回自定义验证
        this.addCustomValidator = function (input, validate, errMsg, tag) {
            return this.add(new CustomValidator(input, validate, errMsg, false, tag));
        };

        this.insert = function (index, validator) {
            _list.splice(index, 0, validator);
        };
        this.get = function (index) {
            if (index >= 0 && index < _list.length) return _list[index];
            return null;
        };
        this.getByInput = function (input) {
            var arr = [];
            for (var i in _list) {
                if (input == _list[i].input) arr.push(_list[i]);
            }
            return arr;
        };
        this.removeAt = function (index) {
            if (index >= 0 && index < _list.length) {
                _list.splice(index, 1);
                return true;
            }
            return false;
        };
        this.remove = function (validator) {
            for (var i in _list) {
                if (validator == _list[i]) return this.removeAt(i);
            }
            return false;
        };
        this.getCount = function () {
            return _list.length;
        };
        this.clear = function () {
            _list = [];
        };
        // 验证
        this.validate = function () {
            var result = true;
            if (validateCallBack == null) {
                for (var i in _list) {
                    var v = _list[i];
                    if (!v.validate()) {
                        alert(v.errMsg);
                        result = false;
                        break;
                    }
                }
            } else {
                for (var i in _list) {
                    var v = _list[i];
                    if (v.validate()) {
                        validateCallBack(true, v);
                    } else {
                        result = false;
                        if (!validateCallBack(false, v)) break;
                    }
                }
            }
            return result;
        };
    };

    window.zjValidatorHandler = zjValidatorHandler;
})();