import { connect } from "react-redux";

import { Reducers } from "@reducers";
import {
    IUsersProps,
    Users
} from "./Users";

const mapStateToProps = (state: Reducers): IUsersProps => {
    return {
        authenticatedUser: state.layoutStore.authenticatedAccount,
        usersThatHaveAccess: state.usersStore.usersThatHaveAccess,
        allUsers: state.usersStore.allUsers
    };
};

const UsersContainer = connect(
    mapStateToProps
)(Users);

export default UsersContainer;
