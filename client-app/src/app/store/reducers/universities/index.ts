import { Reducer } from "redux";
import IUniversityState from "./models/state";
import { UniversityActions, UniversityTypes } from "./actions";

const initialState : IUniversityState = {
    data: [],
    pending: false
};

const UniversityReducer : Reducer<IUniversityState> = (state = initialState, action: UniversityActions) => {


    switch (action.type){

        case UniversityTypes.UNIVERSITY_PENDING:
            return { ...state, pending: true };

        case UniversityTypes.UNIVERSITY_FAIL:
            return { ...state, pending: false, error: action.payload };

        case UniversityTypes.GET_UNIVERSITY_BY_ACRONYM_SUCCESS:
            return { ...state, pending: false, error: false, data: action.payload };
        
        default:
            return state;

    }
};

export default UniversityReducer;