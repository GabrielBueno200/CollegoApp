import { Reducer } from "redux";
import ICourseState from "./models/state";
import { CourseActions, CourseTypes } from "./actions";

const initialState : ICourseState = {
    data: [],
    pending: false
};

const CourseReducer : Reducer<ICourseState> = (state = initialState, action: CourseActions) => {


    switch (action.type){

        case CourseTypes.COURSE_PENDING:
            return { ...state, pending: true };

        case CourseTypes.COURSE_FAIL:
            return { ...state, pending: false, error: action.payload };

        case CourseTypes.GET_COURSES_SUCCESS:
            return { ...state, pending: false, error: false, data: action.payload };
        
        default:
            return state;

    }
};

export default CourseReducer;