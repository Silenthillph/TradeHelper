"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Enums;
(function (Enums) {
    var PositionType;
    (function (PositionType) {
        PositionType[PositionType["Long"] = 1] = "Long";
        PositionType[PositionType["Short"] = 2] = "Short";
    })(PositionType = Enums.PositionType || (Enums.PositionType = {}));
    var PositionStatus;
    (function (PositionStatus) {
        PositionStatus[PositionStatus["Open"] = 1] = "Open";
        PositionStatus[PositionStatus["Closed"] = 2] = "Closed";
    })(PositionStatus = Enums.PositionStatus || (Enums.PositionStatus = {}));
    var CrudOperation;
    (function (CrudOperation) {
        CrudOperation[CrudOperation["Create"] = 1] = "Create";
        CrudOperation[CrudOperation["Update"] = 2] = "Update";
        CrudOperation[CrudOperation["Delete"] = 3] = "Delete";
    })(CrudOperation = Enums.CrudOperation || (Enums.CrudOperation = {}));
})(Enums = exports.Enums || (exports.Enums = {}));
//# sourceMappingURL=enums.js.map