import { CTable, CTableHead, CTableRow, CTableHeaderCell, CTableDataCell, CTableBody } from '@coreui/react';
import '@coreui/coreui/dist/css/coreui.min.css';
import React, { Component } from 'react';


export default class TasksTable extends Component {

    constructor(props) {
        super(props);
        this.state = { tasks: [] };
    }

    render() {
        return (
            <CTable stripped>
                <CTableHead>
                    <CTableRow>
                        <CTableHeaderCell scope="col">#</CTableHeaderCell>
                        <CTableHeaderCell scope="col">Class</CTableHeaderCell>
                        <CTableHeaderCell scope="col">Heading</CTableHeaderCell>
                        <CTableHeaderCell scope="col">Heading</CTableHeaderCell>
                    </CTableRow>
                </CTableHead>
                <CTableBody>
                    <CTableRow>
                    {/*{forecasts.map(x =>*/}
                    {/*    //<CTableHeaderCell scope="row">1</CTableHeaderCell>*/}
                    {/*    //<CTableDataCell>{x.}</CTableDataCell>*/}
                    {/*    //<CTableDataCell>Otto</CTableDataCell>*/}
                    {/*    //<CTableDataCell>@mdo</CTableDataCell>*/}
                    {/*)};*/}
                    </CTableRow>
                </CTableBody>
            </CTable>
        );
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    async populateWeatherData() {
        //const response = await fetch(`api/tasks?${this.props.}`);
        //const data = await response.json();
        //this.setState({ forecasts: data, loading: false });
    }
}