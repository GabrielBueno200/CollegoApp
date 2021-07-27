import { combineReducers } from "redux";
import { UserActions } from "./user/actions";
import { UniversityActions } from "./universities/actions";
import users from './user';
import universities from './universities';

export type AppActions = UserActions | UniversityActions;

export default combineReducers({
    users,
    universities
});