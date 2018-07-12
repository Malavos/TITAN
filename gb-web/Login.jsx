import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import MenuItem from '@material-ui/core/MenuItem';
import TextField from '@material-ui/core/TextField';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardHeader from '@material-ui/core/CardHeader';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import InputIcon from '@material-ui/icons/Input';
import RegisterIcon from '@material-ui/icons/PersonAdd';
import classNames from 'classnames';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import Slide from '@material-ui/core/Slide';


const styles = theme => ({
	container: {
		display: 'flex',
		flexWrap: 'wrap',
	},
	textField: {
		marginLeft: theme.spacing.unit,
		marginRight: theme.spacing.unit,
		width: 200,
	},
	menu: {
		width: 200,
	},
	card: {
		minWidth: 320,
		align: 'center',
		maxWidth: 500
	}
});



function Transition(props) {
  return <Slide direction="up" {...props} />;
}

class Login extends React.Component {

	constructor(props){
		super(props);
		this.state = {
			user: '',
			password: '',
			open: false,
			register: false
		};

		this.handleInputChanged = this.handleInputChanged.bind(this);
		
		this.register = this.register.bind(this);
		this.handleCloseRegister = this.handleCloseRegister.bind(this);
		this.handleClickOpenRegister = this.handleClickOpenRegister.bind(this);

		this.login = this.login.bind(this);
		this.handleClickOpen = this.handleClickOpen.bind(this);
		this.handleClose = this.handleClose.bind(this);
	};



  	handleClickOpen()  {
    	this.setState({ open: true });
  	};
  	handleClose() {
    	this.setState({ open: false });
	};
	login(event){
		if (this.state.user.trim() == '' || this.state.password == ''){
    		this.setState({ open: true });
		}
	};

	register(event){
		this.setState({ register: true });
	};
	handleClickOpenRegister(event){
		this.setState({ register: true });
	};
	handleCloseRegister(event){
		this.setState({ register: false });
	};
	registerNewUser(event){
		alert('Ayyy lmao');
	};

	handleInputChanged(event){
		const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;
        this.setState({
     		[name]: value
		});
	};

	render() {
		const { classes } = this.props;

		return (
			<div className="centerDiv">
				<Card className={classes.card}>
					<CardHeader title="Bem vindo!" subheader="Acesse o sistema para cadastrar os seus débitos."/>
					<CardContent>
						<form className={classes.container} noValidate autoComplete="off">
							<TextField id="inputLogin" name="user" value={this.state.user} fullWidth label="Login" helperText="Digite aqui seu usuário..." className={classes.textField} margin="normal" onChange={this.handleInputChanged} maxLength="64" />
							<TextField id="inputPassword" name="password" value={this.state.password} fullWidth label="Senha" helperText="... e aqui sua senha!" className={classes.textField} margin="normal" onChange={this.handleInputChanged} type="password" maxLength="32"/>
							<div className="rightDiv">
								<Button onClick={this.login} variant="contained"  size="small" color="primary" aria-label="acessar" className={classes.button}>
									<InputIcon className={classNames(classes.leftIcon, classes.iconSmall)} />
									Acessar
								</Button>
								<Button onClick={this.register} variant="contained" size="small" color="secondary" aria-label="Registrar" className={classes.button}>
									<RegisterIcon className={classNames(classes.leftIcon, classes.iconSmall)} />
									Registrar
								</Button>
							</div>
						</form>
					</CardContent>
				</Card>


				<Dialog open={this.state.open} TransitionComponent={Transition} keepMounted onClose={this.handleClose} aria-labelledby="alert-dialog-slide-title" aria-describedby="alert-dialog-slide-description" >
		          <DialogTitle id="alert-dialog-slide-title">
		            {"Atenção"}
		          </DialogTitle>
		          <DialogContent>
		            <DialogContentText id="alert-dialog-slide-description">
		              Por favor informe usuário e senha.
		            </DialogContentText>
		          </DialogContent>
		          <DialogActions>
		            <Button onClick={this.handleClose} color="primary">
		              Desculpa!
		            </Button>
		          </DialogActions>
		        </Dialog>

		        <Dialog open={this.state.register} TransitionComponent={Transition} keepMounted onClose={this.handleCloseRegister} aria-labelledby="dialogTitleRegister" aria-describedby="dialogDescriptionRegister">
		        	<DialogTitle id="dialogTitleRegister">
		        		{"Registro"}
		        	</DialogTitle>
		        	<DialogContent>
		        		<DialogContentText id="dialogDescriptionRegister">
		        			Informe os dados abaixo para realizar o seu cadastro. Todos os dados são obrigatórios.
		        		</DialogContentText>
		        		  <TextField autoFocus margin="normal" id="inputEmailRegister" label="Email" type="email" fullWidth />
		        			<TextField margin="normal" id="inputNameRegister" label="Nome" type="text" fullwidth />
		        			<TextField margin="dense" id="inputPasswordRegister" label="Senha" type="password" fullWidth />
		        			<TextField margin="dense" id="inputPasswordConfirmationRegister" label="Confirme sua senha" type="password" fullWidth />
	        				<TextField margin="dense" id="inputAreaCodeRegister" label="DDD" type="number" maxLength="3" />
	        				<TextField margin="dense" id="inputPhoneRegister" label="Número Celular" type="number" maxLength="13" />
		        	</DialogContent>
		        	<DialogActions>
		        		<Button onClick={this.handleCloseRegister} color="secondary">
              				Cancelar
        				</Button>
			            <Button onClick={this.registerNewUser} color="primary">
			            	Registrar
			            </Button>
		        	</DialogActions>
	        	</Dialog>

			</div>
		);
	}
}

Login.propTypes = {
	classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Login);