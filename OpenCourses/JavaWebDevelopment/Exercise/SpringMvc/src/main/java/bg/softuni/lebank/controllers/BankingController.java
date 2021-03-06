package bg.softuni.lebank.controllers;

import java.text.DateFormat;
import java.util.Date;
import java.util.Locale;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;

import bg.softuni.lebank.constants.OutputMessages;
import bg.softuni.lebank.entities.InputData;
import bg.softuni.lebank.interfaces.AccountsRepository;
import bg.softuni.lebank.interfaces.CurrencyExchange;

@Controller
public class BankingController {
	
	private static final Logger logger = LoggerFactory.getLogger(BankingController.class);	
	private static final String version = "Version: 0.4";
	private static final String project = "Project: Spring MVC Banking Page";
	
	@Autowired
	private AccountsRepository clientsRepository;
	
	@Autowired
	private CurrencyExchange bgnExchange;
	
	@RequestMapping(value = "/")
	public String banking(Locale locale, Model model, @ModelAttribute(value = "SpringWeb") InputData input) {
		logger.info("The client locale is {}.", locale);
		
		Date date = new Date();
		DateFormat dateFormat = DateFormat.getDateTimeInstance(DateFormat.LONG, DateFormat.LONG, locale);
		
		String formattedDate = dateFormat.format(date);
		
		model.addAttribute("serverTime", formattedDate );
		model.addAttribute("project", project);
		model.addAttribute("version", version);

		String output = null;
		String user = input.getClientId();
		user = user == null ? "" : user;
		
		model.addAttribute("clientId", user);
		
		if (!user.equals("") && !user.contains(" ")) {
			String action = input.getSelectedOperation();
			String amount = input.getOperationAmount();
			String currency = input.getSelectedCurrency();
			
			if (action != null && action.equals("deposit")){
				output = this.clientsRepository.deposit(user, amount, currency, bgnExchange);
			} else if (action != null && action.equals("withdraw")){
				output = this.clientsRepository.withdraw(user, amount, currency, bgnExchange);
			} else {
				output = OutputMessages.OPERATION_NOT_SELECTED;
			}
			
			String balance = clientsRepository.getAccountBallance(user);	
			model.addAttribute("currentBallance", "Client balance: " + balance);
		} else {
			output = OutputMessages.VALID_ID_REQUIRED;
		}
		
		model.addAttribute("output", output);
		
		return "banking";
	}
}
