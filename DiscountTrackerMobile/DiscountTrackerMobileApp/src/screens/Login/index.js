import React, { useState } from 'react';
import Icon from 'react-native-vector-icons/FontAwesome';
import {
    StyleSheet,
    Text,
    View,
    Dimensions
} from 'react-native';
import { Input, CheckBox, Button } from 'react-native-elements';


const LoginScreen = () => {

    //-----------------------------States Start-------------------------------------
    const [rememberMe, setRememberMe] = useState(false);
    const [email,setEmail]=useState();
    const [password,setPassword]=useState();
    //-----------------------------States End----------------------------------------




    //-----------------------------Control Events Start------------------------------

    const rememberMeClick = () => {
        console.log("Remember me click... Value :" + rememberMe);
        if (rememberMe == undefined || rememberMe == null || !rememberMe) {
            setRememberMe(true);
        }
        else
            setRememberMe(false);
    }

    //-----------------------------Control Events End--------------------------------


    

    //-----------------------------Custom Functions Start----------------------------

    //-----------------------------Custom Functions End------------------------------





    //----------------------------View Start--------------------------------------
    return (
        <View
            style={styles.rootView}
            contentInsetAdjustmentBehavior="automatic">
            <Input
                style={styles.input}
                placeholder='E-mail'
                leftIcon={
                    <Icon
                        name='user'
                        size={21}
                        color='black'
                    />
                }
                keyboardType='email-address'/>
            <Input style={styles.input} placeholder="Password" 
            leftIcon={
                <Icon name='unlock' size={21} color='black'/>
            }
                secureTextEntry={true} />
            <CheckBox
            style={styles.checkbox}
                title='Beni Hatırla'
                checked={rememberMe}
                onIconPress={rememberMeClick()}/>

            <Text style={styles.text}>
                Hala üye değil misin, hemen <Text style={styles.blueText}> Üye ol!</Text>
            </Text>

            <View style={styles.loginButton}>
                <Button
                    icon={
                        <Icon name="arrow-right" size={15} color="white" />
                    }
                    title="Giriş Yap"
                />
            </View>
        </View>
    );

    //------------------------------View End------------------------------------
};

//---------------------------------Styles Start-----------------------------------
const styles = StyleSheet.create({
    blueText: {
        color: 'blue'
    },
    input: {
        marginTop: Dimensions.get('window').height * 0.01
    },
    loginButton: {
        marginTop: Dimensions.get('window').height * 0.05,
        marginLeft: '10%',
        width: '80%',

    },
    text:{
        width: '80%',
        marginLeft: '20%',
        marginTop: Dimensions.get('window').height * 0.05,
    },
    checkbox:{
        marginTop: Dimensions.get('window').height * 0.1,
    },
    rootView: {
        width: '100%'
    }
});
//---------------------------------Styles End-----------------------------------

export default LoginScreen;