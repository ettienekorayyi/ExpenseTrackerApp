import { combineReducers } from "redux";
import * as actions from "../actions/actionTypes";

const expensesReducer = (state = [], action) => {
  switch (action.type) {
    case actions.NEW_EXPENSE:
      return {
        ...state,
        data: action.payload,
      };
    case actions.FETCH_EXPENSES_BEGIN:
      return {
        ...state,
        loading: true,
        error: null,
      };
    case actions.FETCH_EXPENSES_SUCCESS:
      return {
        ...state,
        data: action.payload,
        loading: false,
      };
    case actions.FETCH_EXPENSES_CREATE:
      return {
        ...state,
        data: action.payload,
        loading: false,
      };
    default:
      return state;
  }
};

export default combineReducers({
  expenses: expensesReducer,
});
