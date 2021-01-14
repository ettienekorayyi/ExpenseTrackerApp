import { Grid } from "semantic-ui-react";
import Header from "../../features/nav/Header";
import ExpensesList from "../../features/expenses/dashboard/ExpensesList";
import CurrentExpenses from "../../features/expenses/dashboard/CurrentExpenses";
import "./styles.css";

function App() {
  return (
    <Grid columns={3} id='expenses'>
      <Grid.Column id='navigation-grid'>
       <Header />
      </Grid.Column>
      <Grid.Column >
        <CurrentExpenses />
        <ExpensesList />
      </Grid.Column>
    </Grid>
  );
}

export default App;
