import { Reducer } from "redux";
import { UserActions, UserTypes } from "./actions";
import IUserState from "./models/state";

const initialState: IUserState = {
    data: {},
    pending: false,
};

const UserReducer: Reducer<IUserState> = (state = initialState, action: UserActions) => {

    switch (action.type){

        case UserTypes.USER_PENDING :
            return { ...state, pending: true };
        
        case UserTypes.USER_FAIL :
            return { ...state, error: action.payload, pending: false };
            
        case UserTypes.LOADED_USER_SUCCESS :
            return { ...state, data: action.payload, pending: false };

        case UserTypes.USER_REGISTERED_SUCCESS :
            return { ...state, error: null, pending: false, 
                    successMessage: action.payload.successMessage };

        case UserTypes.USER_LOGGEDIN_SUCCESS :
            return { ...state, error: null, pending: false, data: action.payload }

        case UserTypes.USER_EXIT_SUCCESS :
            return { ...state, pending: false, user: {}};
        
        case UserTypes.CLEAR_USER_ERRORS :
            return { ...state, error: null };
        
        default:
            return state;
    }

};

export default UserReducer;