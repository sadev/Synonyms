import { TextBoxComponent } from '@syncfusion/ej2-react-inputs';
import * as React from "react";
import * as ReactDOM from "react-dom";

export default class App extends React.Component<{}, {}> {
    public render() {
        return (
            // element which is going to render the TextBox
            <TextBoxComponent placeholder="Search Synonym floatLabelType="Auto" />
        );
    }
};