import { applyMiddleware, createStore, Store, compose } from 'redux';
import thunk, { ThunkAction, ThunkDispatch, ThunkMiddleware } from 'redux-thunk';
import rootReducer, { AppActions } from './reducers'

/*Custom Thunk Types*/
export type AppState = ReturnType<typeof rootReducer>;
export type AppDispatch = ThunkDispatch<AppState, undefined, AppActions>;
export type AsyncAction = ThunkAction<Promise<void>, AppState, undefined, AppActions>;
/* */

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const store: Store<AppState> = createStore(
    rootReducer,
    composeEnhancers(
        applyMiddleware(thunk as ThunkMiddleware<AppState, AppActions>)
    )
);

export default store;