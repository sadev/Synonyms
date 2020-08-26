import { DataManager, WebApiAdaptor } from '@syncfusion/ej2-data';
import { ColumnDirective, ColumnsDirective, GridComponent } from '@syncfusion/ej2-react-grids';
import { Edit, EditSettingsModel, Inject, Toolbar, ToolbarItems, Page, PageSettingsModel } from '@syncfusion/ej2-react-grids';
import * as React from 'react';

export default class App extends React.Component<{}, {}>{
    public editOptions: EditSettingsModel = { allowEditing: true, allowAdding: true, allowDeleting: true, mode: 'Normal' };
    public toolbarOptions: ToolbarItems[] = ['Add', 'Edit', 'Delete', 'Update', 'Cancel'];
    public pageOptions: PageSettingsModel = {
        pageSize: 3, pageSizes: true
    };
    public data = new DataManager({
        adaptor: new WebApiAdaptor,
        url: 'synonym'
    });
    public render() {
        return <GridComponent dataSource={this.data} editSettings={this.editOptions} toolbar={this.toolbarOptions} allowPaging={true}  pageSettings={this.pageOptions}>
            <ColumnsDirective>
                <ColumnDirective field='id' headerText='ID' width='120' visible={false} isPrimaryKey={true} textAlign="Right"  />
                <ColumnDirective field='keyword' headerText='Keyword' width='150' />
                <ColumnDirective field='synonym' headerText='Synonym' width='150' />
            </ColumnsDirective>
            <Inject services={[Edit, Toolbar, Page]} />
        </GridComponent>
    }
};


