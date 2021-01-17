import { Grid, Header as SemanticUIHeader } from "semantic-ui-react";
import Header from "../../features/nav/Header";
import ExpensesList from "../../features/expenses/dashboard/ExpensesList";
import ExpensesSummary from "../../features/expenses/dashboard/ExpensesSummary";
import ExpensesCategory from "../../features/expenses/dashboard/ExpensesCategory";
import Categories from "../../features/categories/Categories";
import "./styles.css";

function App() {
  return (
    <Grid columns={3} id="expenses">
      <Grid.Column id="navigation-grid">
        <Header />
      </Grid.Column>
      <Grid.Column id="expenses-grid">
        <ExpensesSummary />
        <ExpensesList />
      </Grid.Column>
      <Grid.Column id="misc-grid">
        <Grid.Row>
          <SemanticUIHeader as="h2" style={{ color: "white" }}>
            Search Feature
          </SemanticUIHeader>
        </Grid.Row>
        <Grid.Row>
          <ExpensesCategory />
        </Grid.Row>
      </Grid.Column>
    </Grid>
  );
}

export default App;
