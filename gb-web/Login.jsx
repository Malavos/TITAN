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
			open: false
		};

		this.handleInputChanged = this.handleInputChanged.bind(this);
		this.logar = this.logar.bind(this);
		this.handleClickOpen = this.handleClickOpen.bind(this);
		this.handleClose = this.handleClose.bind(this);
	};



  	handleClickOpen()  {
    	this.setState({ open: true });
  	};

  	handleClose() {
    	this.setState({ open: false });
	};


	logar(event){
		console.log(this);
		console.log(event);
		if (this.state.user.trim() == '' || this.state.password == ''){
    		this.setState({ open: true });
		}
	};

	handleInputChanged(event){
		const target = event.target;
	};

	render() {
		const { classes } = this.props;

		return (
			<div className="centerDiv">
				<Card className={classes.card}>
					<CardHeader title="Bem vindo!" subheader="Acesse o sistema para cadastrar os seus débitos."/>
					<CardContent>
						<form className={classes.container} noValidate autoComplete="off">
							<TextField id="inputLogin" value={this.state.user} fullWidth label="Login" helperText="Digite aqui seu usuário..." className={classes.textField} margin="normal" maxLength="64" />
							<TextField id="inputPassword" value={this.state.password} fullWidth label="Senha" helperText="... e aqui sua senha!" className={classes.textField} margin="normal" type="password" maxLength="32"/>
							<div className="rightDiv">
								<Button onClick={this.logar} variant="contained"  size="small" color="primary" aria-label="acessar" className={classes.button}>
									<InputIcon className={classNames(classes.leftIcon, classes.iconSmall)} />
									Acessar
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
			</div>
		);
	}
}

Login.propTypes = {
	classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Login);