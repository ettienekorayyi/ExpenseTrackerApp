import React from "react";
import {
  Button,
  Header as SemantiUiHeader,
  TextArea,
  Divider,
  Icon,
  Input,
  Form,
  Segment,
} from "semantic-ui-react";
import { connect } from "react-redux";
import * as actions from "../../../actions";

const toggle = () => {
  // keeps on loading infinitely
  // fix this
  let formElement = document.getElementById("form");
  formElement.classList.toggle("loading");
};

let expense = {
  budget: 0.0,
  description: "",
  // category
  shop: "",
  amount: 0.0,
  // date
};

const NewExpense = ({ expenses, dispatch }) => {
  console.log(expenses);

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
          <Form.Field label="Category" control="select">
            <option value="category">Select a category</option>
            <option value="bills">Bills</option>
            <option value="grocery">Grocery</option>
          </Form.Field>
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
            label="Budget"
            control={Input}
            placeholder="Budget"
            onChange={(e) => (expense.budget = e.target.value)}
          />
        </Form.Group>
        <Form.Group>
          <Form.Field label="Date" control={Input} placeholder="Date" />
        </Form.Group>

        <Button.Group>
          <Button>Cancel</Button>
          <Button.Or />
          <Button
            positive
            onClick={() => dispatch(actions.addExpense(expense))}
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
