import { applyMiddleware, createStore, Store } from 'redux';
import thunk, { ThunkAction, ThunkDispatch, ThunkMiddleware } from 'redux-thunk';
import rootReducer, { AppActions } from './reducers'

/*Custom Thunk Types*/
export type AppState = ReturnType<typeof rootReducer>;
export type AppDispatch = ThunkDispatch<AppState, undefined, AppActions>;
export type AsyncAction = ThunkAction<Promise<void>, AppState, undefined, AppActions>;
/* */


const store: Store<AppState> = createStore(
    rootReducer,
    applyMiddleware(thunk as ThunkMiddleware<AppState, AppActions>)
);

export default store;