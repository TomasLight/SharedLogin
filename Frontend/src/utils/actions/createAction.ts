import { AnyAction } from "redux";

export function createAction(actionType: string, payload: any = {}): AnyAction {
    let _payload;

    if (typeof payload == "object" && !Array.isArray(payload)) {
        _payload = { ...payload };
    } else {
        _payload = payload;
    }

    return {
        type: actionType,
        payload: _payload
    };
}
