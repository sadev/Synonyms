import { DataManager, WebApiAdaptor } from '@syncfusion/ej2-data';
import { ColumnDirective, ColumnsDirective, FailureEventArgs, Grid, GridComponent } from '@syncfusion/ej2-react-grids';
import { Edit, EditSettingsModel, Inject, Toolbar, ToolbarItems, Page, PageSettingsModel } from '@syncfusion/ej2-react-grids';
import * as React from 'react';

export default class Administration extends React.Component<{}, {}>{
    public editOptions: EditSettingsModel = { allowEditing: true, allowAdding: true, allowDeleting: true, mode: 'Normal' };
    public toolbarOptions: ToolbarItems[] = ['Add', 'Edit', 'Delete', 'Update', 'Cancel'];
    public pageOptions: PageSettingsModel = {
        pageSize: 3, pageSizes: true
    };
    public data = new DataManager({
        adaptor: new WebApiAdaptor,
        url: 'synonym'
    });
    public grid: Grid | null;
    public render() {
        this.onActionFailure = this.onActionFailure.bind(this);
        return <GridComponent dataSource={this.data} ref={g => this.grid = g} editSettings={this.editOptions} toolbar={this.toolbarOptions} allowPaging={true} pageSettings={this.pageOptions} actionFailure={this.onActionFailure}>
            <ColumnsDirective>
                <ColumnDirective field='id' headerText='ID' width='120' visible={false} isPrimaryKey={true} textAlign="Right"  />
                <ColumnDirective field='keyword' headerText='Keyword' width='150' />
                <ColumnDirective field='synonym' headerText='Synonym' width='150' />
            </ColumnsDirective>
            <Inject services={[Edit, Toolbar, Page]} />
        </GridComponent>
    }

    public onActionFailure = (e: FailureEventArgs) => {
        const span: HTMLElement = document.createElement('span');
        if (this.grid) {
            debugger;
            (this.grid.element.parentNode as HTMLElement).insertBefore(span, this.grid.element);
            span.style.color = "#FF0000";
            span.innerHTML = JSON.parse(e.error[0].error.response).message;
        }
    }
};


