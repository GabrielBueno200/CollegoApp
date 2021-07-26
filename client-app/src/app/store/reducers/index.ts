import { combineReducers } from "redux";
import { UserActions } from "./user/actions";
import { UniversityActions } from "./universities/actions";
import users from './user';

export type AppActions = UserActions | UniversityActions;

export default combineReducers({
    users
});