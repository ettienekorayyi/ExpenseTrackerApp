import React, { useState } from "react";
import {
  Button,
  Header as SemantiUiHeader,
  TextArea,
  Divider,
  Icon,
  Input,
  Form,
  Segment,
  Select,
} from "semantic-ui-react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { connect } from "react-redux";
import * as actions from "../../../actions";

/*
const toggle = () => {
   keeps on loading infinitely
   fix this
  let formElement = document.getElementById("form");
  formElement.classList.toggle("loading");
};
*/

const options = [
  { key: 1, text: "Bills", value: 'bills' },
  { key: 2, text: "Grocery", value: 'grocery' },
];

let expense = {
  description: "",
  category: "",
  shop: "",
  quantity: 0,
  amount: 0.0,
  date: "",
};

const NewExpense = ({ expenses, dispatch }) => {
  const [startDate, setStartDate] = useState(new Date());
  
  console.log(expenses);

  const dateSetter = (current) => {
    let date = new Date(current);
    setStartDate(date);
    
    console.log(date.toISOString());
    expense.date = date.toISOString();
  };


  return (
    <Segment>
      <Form id="form">
        <Divider horizontal>
          <SemantiUiHeader as="h1">
            <Icon name="tag" />
            Add New Expense
          </SemantiUiHeader>
        </Divider>

        <Form.Group>
          <Form.Field
            label="Category"
            control={Select}
            options={options}
            clearable
            onChange={(e, { value }) => expense.category = value}
          />

          <Form.Field
            label="Shop"
            control={Input}
            placeholder="Shop"
            onChange={(e) => (expense.shop = e.target.value)}
          />
        </Form.Group>

        <Form.Field
          label="Description"
          control={TextArea}
          onChange={(e) => (expense.description = e.target.value)}
        />

        <Form.Group>
          <Form.Field
            label="Amount"
            control={Input}
            placeholder="Amount"
            onChange={(e) => (expense.amount = e.target.value)}
          />
          <Form.Field
            label="Quantity"
            control={Input}
            placeholder="Quantity"
            onChange={(e) => (expense.quantity = e.target.value)}
          />
        </Form.Group>
        <Form.Group>
          <DatePicker
            selected={startDate}
            onChange={(date) => dateSetter(date)} 
          />
        </Form.Group>

        <Button.Group>
          <Button>Cancel</Button>
          <Button.Or />
          <Button
            positive
            onClick={() => dispatch(actions.createExpenses(expense)) } 
          >
            Submit
          </Button>
        </Button.Group>
      </Form>
    </Segment>
  );
};

function mapStateToProps(state) {
  return {
    expenses: state.expenses,
  };
}

export default connect(mapStateToProps)(NewExpense);
