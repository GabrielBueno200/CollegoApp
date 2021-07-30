import { combineReducers } from "redux";

/* Action Types */
import { UserActions } from "./user/actions";
import { CourseActions } from "./courses/actions";
import { UniversityActions } from "./universities/actions";

/* Reducers */
import users from './user';
import courses from './courses';
import universities from './universities';

export type AppActions = UserActions | UniversityActions | CourseActions;

export default combineReducers({
    users,
    courses,
    universities
});