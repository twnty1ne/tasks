import React, { Component } from 'react';
import TasksTable from "./components/TasksTable.js"
import DateRangePicker from 'react-bootstrap-daterangepicker';
// you will need the css that comes with bootstrap@3. if you are using
// a tool like webpack, you can do the following:
import 'bootstrap/dist/css/bootstrap.css';
// you will also need the css that comes with bootstrap-daterangepicker
import 'bootstrap-daterangepicker/daterangepicker.css';


export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
    }

    


    render() {
        const styles = { width: 260, marginBottom: 10 };
        return (
            <div>
                <div>
                    <DateRangePicker
                        initialSettings={{ startDate: '1/1/2014', endDate: '3/1/2014' } }
                    >
                        <button>Click Me To Open Picker!</button>
                    </DateRangePicker>
                </div>
                <div>
                    <TasksTable/>
                </div>
                
            </div>
        );
    }
}
