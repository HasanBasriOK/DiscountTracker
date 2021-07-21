import React, { useState } from 'react';
import Icon from 'react-native-vector-icons/FontAwesome';
import {
    StyleSheet,
    Text,
    View,
    Dimensions
} from 'react-native';
import { Input, CheckBox, Button } from 'react-native-elements';


const MainPage = () => {

    //-----------------------------States Start-------------------------------------
    //-----------------------------States End----------------------------------------


    //-----------------------------Control Events Start------------------------------
    //-----------------------------Control Events End--------------------------------


    //-----------------------------Custom Functions Start----------------------------
    //-----------------------------Custom Functions End------------------------------


    //----------------------------View Start--------------------------------------
    return (
        <View
            style={styles.rootView}
            contentInsetAdjustmentBehavior="automatic">
            <Text style={styles.text}>
               Main Page
            </Text>
           
        </View>
    );
    //------------------------------View End------------------------------------
};

//---------------------------------Styles Start-----------------------------------
//---------------------------------Styles End-----------------------------------

export default MainPage;