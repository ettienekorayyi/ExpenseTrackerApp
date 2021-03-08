import { BrowserRouter as Router, Route } from "react-router-dom";
import Header from "../../features/nav/Header";
import ExpensesContent from "../../features/expenses/details/ExpensesContent";
import Dashboard from "../../features/expenses/home/Dashboard";
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
