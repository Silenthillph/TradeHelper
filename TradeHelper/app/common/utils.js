"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Utils;
(function (Utils) {
    function getNewGUID() {
        var d = new Date().getTime();
        var newGuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d / 16);
            return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
        return newGuid;
    }
    Utils.getNewGUID = getNewGUID;
    function getEmptyGUID() {
        return '00000000-0000-0000-0000-000000000000';
    }
    Utils.getEmptyGUID = getEmptyGUID;
})(Utils = exports.Utils || (exports.Utils = {}));
//# sourceMappingURL=utils.js.map