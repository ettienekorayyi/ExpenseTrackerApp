import React from "react";
import ReactDOM from "react-dom";
import "semantic-ui-css/semantic.min.css";
import "./index.css";
import App from "./app/layout/App";
import { Provider } from "react-redux";
import store from "./store";
import * as actions from './actions';

//store.dispatch(actions.addExpense());
//store.dispatch(actions.addExpense());
//console.log(store.getState());
// send the store to the provider and use props to access the dispatch
ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <App />
    </Provider>
  </React.StrictMode>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
//reportWebVitals();
