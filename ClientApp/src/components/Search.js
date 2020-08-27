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
var App = /** @class */ (function (_super) {
    __extends(App, _super);
    function App() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    App.prototype.btnClick = function () {
        var _this = this;
        fetch("search/" + this.search.value)
            .then(function (response) { return response.json(); })
            .then(function (data) {
            _this.chipList.add(data);
        });
    };
    App.prototype.render = function () {
        var _this = this;
        return (React.createElement("div", { className: "container" },
            React.createElement("div", { className: "row" },
                React.createElement("div", { className: "col-8" },
                    React.createElement(ej2_react_inputs_1.TextBoxComponent, { id: "search", name: "search", ref: function (scope) { _this.search = scope; }, placeholder: "Search Synonym", floatLabelType: "Auto" })),
                React.createElement("div", { className: "col-4 search-button" },
                    React.createElement(ej2_react_buttons_1.ButtonComponent, { cssClass: 'e-success', onClick: this.btnClick.bind(this) }, "Search"))),
            React.createElement("div", { className: "row chip-list" },
                React.createElement(ej2_react_buttons_1.ChipListComponent, { id: "chip-avatar", ref: function (scope) { _this.chipList = scope; }, enableDelete: true }))));
    };
    return App;
}(React.Component));
exports.default = App;
;
//# sourceMappingURL=Search.js.map