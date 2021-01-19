import {
  Segment,
  Button,
  Grid,
  Item,
  Header as SemanticUIHeader,
} from "semantic-ui-react";
import ExpensesList from "./ExpensesList";

const ExpensesContent = () => {
  return (
    <Grid columns={3}>
      <Grid.Column id="navigation-grid" />
      <Grid.Column id="expenses-list-grid">
        <Segment.Group>
          <Segment id="expenses-content">
            <Grid.Row className='expenses-content-row'>
              <ExpensesList />
            </Grid.Row>
            <Grid.Row className='expenses-content-row'>
              <Segment>
                <Button secondary>
                  <span><i className='plus icon'></i></span>
                </Button>
              </Segment>
            </Grid.Row>
          </Segment>
        </Segment.Group>
      </Grid.Column>
      <Grid.Column id="expenses-crud-grid">
        <Grid.Row className='expenses-content-row'>
          <SemanticUIHeader as="h2" style={{ color: "white" }}>
            Add New Expense
          </SemanticUIHeader>
        </Grid.Row>
      </Grid.Column>
    </Grid>
  );
};

export default ExpensesContent;
