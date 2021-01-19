import { Grid, Header as SemanticUIHeader } from "semantic-ui-react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Header from "../../features/nav/Header";
import ExpensesList from "../../features/expenses/dashboard/ExpensesList";
import ExpensesContent from "../../features/expenses/dashboard/ExpensesContent";
import ExpensesSummary from "../../features/expenses/dashboard/ExpensesSummary";
import ExpensesCategory from "../../features/expenses/dashboard/ExpensesCategory";
import Dashboard from "../../features/expenses/dashboard/Dashboard";
import Categories from "../../features/categories/Categories";
import "./styles.css";

function App() {
  /* 
  
  */

  return (
    <Router>
      <div className="default">
        <Header />
        <Route exact path="/" component={Dashboard} />
        <Route path="/expenses" component={ExpensesContent} />
      </div>
    </Router>
  );
}

export default App;
