import { Grid, Header as SemanticUIHeader } from "semantic-ui-react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Header from "../../features/nav/Header";
import ExpensesList from "../../features/expenses/details/ExpensesList";
import ExpensesContent from "../../features/expenses/details/ExpensesContent";
import ExpensesSummary from "../../features/expenses/details/ExpensesSummary";
import ExpensesCategory from "../../features/expenses/details/ExpensesCategory";
import Dashboard from "../../features/expenses/home/Dashboard";
import Categories from "../../features/categories/Categories";
import "./styles.css";

function App() {
 
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
