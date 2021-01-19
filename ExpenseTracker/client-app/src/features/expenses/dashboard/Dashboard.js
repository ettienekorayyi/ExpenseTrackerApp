import { Grid, Header as SemanticUIHeader, Segment } from "semantic-ui-react";
import Header from "../../nav/Header";
import ExpensesList from "../dashboard/ExpensesList";
import ExpensesSummary from "../dashboard/ExpensesSummary";
import ExpensesCategory from "../dashboard/ExpensesCategory";
import Categories from "../../categories/Categories";
import "../../../app/layout/styles.css";

const Dashboard = () => {
  return (
    <Grid columns={3}>
      <Grid.Column id="navigation-grid" />
      <Grid.Column id="dashboard-expenses-grid">
        <Segment id="expenses-summary">
          <ExpensesSummary />
        </Segment>
        <Segment id="expenses-list">
          <ExpensesList />
        </Segment>
      </Grid.Column>
      <Grid.Column id="dashboard-misc-grid">
        <Grid.Row className='dashboard-content-row'>
          <SemanticUIHeader as="h2" style={{ color: "white" }}>
            Search Feature
          </SemanticUIHeader>
        </Grid.Row>
        <Grid.Row className='dashboard-content-row'>
          <ExpensesCategory />
        </Grid.Row>
      </Grid.Column>
    </Grid>
  );
};

export default Dashboard;
