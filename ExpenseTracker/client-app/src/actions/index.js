import * as actions from './actionTypes';

let initialState = {
  budget: 0.00,
  description: '',
  category: '',
  shop: '',
  amount: 0.00,
  date: '',
};

export function addExpense(expense = initialState) {
  return {
    type: actions.NEW_EXPENSE,
    payload: {
      budget: expense.budget,
      description: expense.description,
      category: "test category",
      shop: expense.shop,
      amount: expense.amount,
      date: "June 2020",
    },
  };
}
