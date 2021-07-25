import React, { useEffect, useState } from 'react';
import Icon from 'react-native-vector-icons/FontAwesome';
import { FontAwesomeIcon } from '@fortawesome/react-native-fontawesome'
import { faCoffee, faUser, faSave, faMagic, faEnvelope, faUserTag, faPhone, faCalendarAlt, faKey } from '@fortawesome/free-solid-svg-icons'
import {
    StyleSheet,
    Text,
    View,
    Dimensions,
    TextInput,
    Keyboard
} from 'react-native';
import { Input, CheckBox, Button } from 'react-native-elements';
import { useNavigation } from '@react-navigation/native';
import md5 from "react-native-md5";
import DatePicker from 'react-native-datepicker'
import TextInputMask from 'react-native-text-input-mask';


const RegisterScreen = () => {
    const navigation = useNavigation();

    //#region Constructors

    useEffect(() => {

    }, []);

    //#endregion

    //#region States 
    const [rememberMe, setRememberMe] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [birthDate, setBirthDate] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');

    //#endregion

    //#region Control Events


    // this.props.navigation.navigate('HomeScreen');

    //#endregion

    //#region Custom Functions 



    //#endregion

    //#region View
    return (
        <View
            style={styles.rootView}
            contentInsetAdjustmentBehavior="automatic">
            <TextInput style={{
                width: 350,
                height: 40,
                padding: 5,
                margin: 5,
                borderWidth: 1,
                borderColor: 'grey',
                borderStyle: 'solid',
                borderRadius: 3
            }} placeholder="Name"
                leftIcon={
                    <FontAwesomeIcon icon={faUser} />
                }
            />
            <TextInput style={styles.input} placeholder="Surname"
                leftIcon={
                    <FontAwesomeIcon icon={faUserTag} />
                }
            />
            <TextInput
                style={styles.input}
                placeholder='E-mail'
                leftIcon={
                    <FontAwesomeIcon
                        icon={faEnvelope}
                    />
                }
                keyboardType='email-address' />
          

            <TextInputMask
                placeholder="Phone Number(090 000 000 00 00)"
                style={{
                    width: 350,
                    height: 40,
                    padding: 5,
                    margin: 5,
                    borderWidth: 1,
                    borderColor: 'grey',
                    borderStyle: 'solid',
                    borderRadius: 3
                }}

                onChangeText={(formatted, extracted) => {
                    setPhoneNumber(formatted);
                    console.log(formatted) // +1 (123) 456-78-90
                    console.log(extracted) // 1234567890
                }}

                mask={"+([000])[000] [000] [00] [00]"}
            />

            <TextInputMask
                placeholder="Birth Date"
                style={{
                    width: 350,
                    height: 40,
                    padding: 5,
                    margin: 5,
                    borderWidth: 1,
                    borderColor: 'grey',
                    borderStyle: 'solid',
                    borderRadius: 3
                }}

                onChangeText={(formatted, extracted) => {
                    console.log(formatted) // +1 (123) 456-78-90
                    console.log(extracted) // 1234567890
                }}

                mask={"[00]{.}[00]{.}[9900]"}
            />

            <TextInput style={styles.input} placeholder="Password"
                leftIcon={
                    <FontAwesomeIcon icon={faKey} />
                }
                secureTextEntry={true} />
            <TextInput style={styles.input} placeholder="Password Repeat"
                leftIcon={
                    <FontAwesomeIcon icon={faKey} />
                }
                secureTextEntry={true} />
            <CheckBox
                title={<Text><Text style={styles.blueText}>Şartları ve Koşulları</Text> okudum,kabul ediyorum</Text>}
                checked={rememberMe}
            />

            <View style={styles.loginButton}>
                <Button
                    icon={
                        <FontAwesomeIcon icon={faSave} />
                    }
                    title=" Kayıt Ol"

                />
            </View>
        </View>
    );

    //#endregion
};

//#region Styles
const styles = StyleSheet.create({
    blueText: {
        color: 'blue'
    },
    input: {
        width: 350,
        height: 40,
        padding: 5,
        margin: 5,
        borderWidth: 1,
        borderColor: 'grey',
        borderStyle: 'solid',
        borderRadius: 3
    },
    loginButton: {
        marginTop: Dimensions.get('window').height * 0.05,
        marginLeft: '10%',
        width: '80%',

    },
    text: {
        width: '80%',
        marginLeft: '20%',
        marginTop: Dimensions.get('window').height * 0.05,
    },
    checkbox: {
        marginTop: Dimensions.get('window').height * 0.1,
    },
    rootView: {
        width: '100%'
    }
});
//#endregion

export default RegisterScreen;