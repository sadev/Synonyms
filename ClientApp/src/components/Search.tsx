﻿import { TextBoxComponent } from '@syncfusion/ej2-react-inputs';
import { enableRipple } from '@syncfusion/ej2-base';
import { ButtonComponent, ChipListComponent } from '@syncfusion/ej2-react-buttons';
import * as React from "react";
import * as ReactDOM from "react-dom";

enableRipple(true);

export default class Search extends React.Component<{}, {}> {
    public search: TextBoxComponent | null | undefined;
    public chipList: ChipListComponent | null | undefined;

    btnClick() {
        fetch(`search/${this.search.value}`)
            .then(response => response.json() as Promise<[]>)
            .then(data => {
                this.chipList.chips = [];
                this.chipList.add(data);
            });        
    }

    public componentWillUnmount() {
        this.chipList.chips = [];
    }

    public render() {
        return (
            <div className="container">
                <div className="row">
                <div className="col-10">
                        <TextBoxComponent id="search" name="search" ref={(scope) => { this.search = scope; }}  placeholder="Search Synonym" floatLabelType="Auto" />
                </div>
                    <div className="col-2 search-button">
                      <ButtonComponent cssClass='e-success' onClick={this.btnClick.bind(this)}>Search</ButtonComponent>
                    </div>
                </div>
                <div id="resultList" className="row chip-list">
                    <ChipListComponent id="chip-avatar" ref={(scope) => { this.chipList = scope; }} enableDelete={true}></ChipListComponent>
                </div>
            </div>
        );
    }
};