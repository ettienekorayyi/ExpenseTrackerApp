import { Grid } from "semantic-ui-react";
import Header from "../../features/nav/Header";
import ExpensesList from "../../features/expenses/dashboard/ExpensesList";
//import RecentExpensesList from "../../features/expenses/dashboard/RecentExpensesList";
import "./styles.css";

function App() {
  return (
    <Grid columns={3} >
      <Grid.Column id='navigation-grid'>
       <Header />
      </Grid.Column>
      <Grid.Column id='expenses-grid'>
        
        <ExpensesList />
      </Grid.Column>
    </Grid>
  );
}

export default App;
