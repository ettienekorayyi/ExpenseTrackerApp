import * as actions from "./actionTypes";

let initialState = {
  description: "",
  category: "",
  shop: "",
  quantity: 0,
  amount: 0.0,
  date: "",
};

export function addExpense(expense = initialState) {
  return {
    type: actions.NEW_EXPENSE,
    payload: {
      description: expense.description,
      category: expense.category,
      shop: expense.shop,
      quantity: expense.quantity,
      amount: expense.amount,
      date: expense.date,
    },
  };
}

// Consuming API

export function fetchExpenses() {
  return (dispatch) => {
    dispatch(fetchExpensesBegin());
    return fetch("https://localhost:5001/api/expenses")
      .then(handleErrors)
      .then((res) => res.json())
      .then((json) => {
        dispatch(fetchExpensesSuccess(json));
        return json;
      })
      .catch((error) => dispatch(fetchExpensesFailure(error)));
  };
}

export function createExpenses(expense = initialState) {
  let date = new Date(expense.date);
  
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({
      description: expense.description,
      category: expense.category,
      shop: expense.shop,
      quantity: parseInt(expense.quantity),
      amount: parseFloat(expense.amount),
      date: date,
    }),
  };

  return (dispatch) => {
    dispatch(fetchExpensesBegin());
    return fetch("https://localhost:5001/api/expenses", requestOptions)
      .then(handleErrors)
      .then((res) => res.json())
      .then((json) => {
        dispatch(fetchExpensesSuccess(json));
        return json;
      })
      .catch((error) => dispatch(fetchExpensesFailure(error)));
  };
}

// Handle HTTP errors since fetch won't.
function handleErrors(response) {
  if (!response.ok) {
    throw Error(response.statusText);
  }
  return response;
}

export const fetchExpensesBegin = () => ({
  type: actions.FETCH_EXPENSES_BEGIN,
});

export const fetchExpensesSuccess = (expenses) => ({
  type: actions.FETCH_EXPENSES_SUCCESS,
  payload: { expenses },
});

export const fetchExpensesFailure = (error) => ({
  type: actions.FETCH_EXPENSES_FAILURE,
  payload: { error },
});
