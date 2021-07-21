import { combineReducers } from "redux";
import { UserActions } from "./user/actions";
import users from './user';

export type AppActions = UserActions;

export default combineReducers({
    users
});