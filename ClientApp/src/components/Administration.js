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
var ej2_data_1 = require("@syncfusion/ej2-data");
var ej2_react_grids_1 = require("@syncfusion/ej2-react-grids");
var ej2_react_grids_2 = require("@syncfusion/ej2-react-grids");
var React = require("react");
var Administration = /** @class */ (function (_super) {
    __extends(Administration, _super);
    function Administration() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.editOptions = { allowEditing: true, allowAdding: true, allowDeleting: true, mode: 'Normal' };
        _this.toolbarOptions = ['Add', 'Edit', 'Delete', 'Update', 'Cancel'];
        _this.pageOptions = {
            pageSize: 3, pageSizes: true
        };
        _this.data = new ej2_data_1.DataManager({
            adaptor: new ej2_data_1.WebApiAdaptor,
            url: 'synonym'
        });
        _this.onActionFailure = function (e) {
            var span = document.createElement('span');
            if (_this.grid) {
                debugger;
                _this.grid.element.parentNode.insertBefore(span, _this.grid.element);
                span.style.color = "#FF0000";
                span.innerHTML = JSON.parse(e.error[0].error.response).message;
            }
        };
        return _this;
    }
    Administration.prototype.render = function () {
        var _this = this;
        this.onActionFailure = this.onActionFailure.bind(this);
        return React.createElement(ej2_react_grids_1.GridComponent, { dataSource: this.data, ref: function (g) { return _this.grid = g; }, editSettings: this.editOptions, toolbar: this.toolbarOptions, allowPaging: true, pageSettings: this.pageOptions, actionFailure: this.onActionFailure },
            React.createElement(ej2_react_grids_1.ColumnsDirective, null,
                React.createElement(ej2_react_grids_1.ColumnDirective, { field: 'id', headerText: 'ID', width: '120', visible: false, isPrimaryKey: true, textAlign: "Right" }),
                React.createElement(ej2_react_grids_1.ColumnDirective, { field: 'keyword', headerText: 'Keyword', width: '150' }),
                React.createElement(ej2_react_grids_1.ColumnDirective, { field: 'synonym', headerText: 'Synonym', width: '150' })),
            React.createElement(ej2_react_grids_2.Inject, { services: [ej2_react_grids_2.Edit, ej2_react_grids_2.Toolbar, ej2_react_grids_2.Page] }));
    };
    return Administration;
}(React.Component));
exports.default = Administration;
;
//# sourceMappingURL=Administration.js.map