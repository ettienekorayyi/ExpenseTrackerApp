import { combineReducers } from 'redux';
import * as actions from '../actions/actionTypes';

const expensesReducer = (state = [], action) => {
    switch(action.type) {
        case actions.NEW_EXPENSE:
            return [ ...state, action.payload];
        default:
            return state;
    }
};


export default combineReducers({
    expenses: expensesReducer
});