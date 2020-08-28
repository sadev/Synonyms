"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var ej2_react_inputs_1 = require("@syncfusion/ej2-react-inputs");
var ej2_base_1 = require("@syncfusion/ej2-base");
var ej2_react_buttons_1 = require("@syncfusion/ej2-react-buttons");
var React = require("react");
ej2_base_1.enableRipple(true);
var Search = /** @class */ (function (_super) {
    __extends(Search, _super);
    function Search() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Search.prototype.btnClick = function () {
        var _this = this;
        fetch("search/" + this.search.value)
            .then(function (response) { return response.json(); })
            .then(function (data) {
            _this.chipList.chips = [];
            _this.chipList.add(data);
        });
    };
    Search.prototype.componentWillUnmount = function () {
        this.chipList.chips = [];
    };
    Search.prototype.render = function () {
        var _this = this;
        return (React.createElement("div", { className: "container" },
            React.createElement("div", { className: "row" },
                React.createElement("div", { className: "col-10" },
                    React.createElement(ej2_react_inputs_1.TextBoxComponent, { id: "search", name: "search", ref: function (scope) { _this.search = scope; }, placeholder: "Search Synonym", floatLabelType: "Auto" })),
                React.createElement("div", { className: "col-2 search-button" },
                    React.createElement(ej2_react_buttons_1.ButtonComponent, { cssClass: 'e-success', onClick: this.btnClick.bind(this) }, "Search"))),
            React.createElement("div", { id: "resultList", className: "row chip-list" },
                React.createElement(ej2_react_buttons_1.ChipListComponent, { id: "chip-avatar", ref: function (scope) { _this.chipList = scope; }, enableDelete: true }))));
    };
    return Search;
}(React.Component));
exports.default = Search;
;
//# sourceMappingURL=Search.js.map