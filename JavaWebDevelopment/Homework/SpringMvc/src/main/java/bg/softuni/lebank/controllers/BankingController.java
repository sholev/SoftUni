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
import org.springframework.web.bind.annotation.RequestMethod;

import bg.softuni.lebank.entities.InputData;
import bg.softuni.lebank.interfaces.AccountsRepository;
import bg.softuni.lebank.interfaces.CurrencyExchange;

@Controller
public class BankingController {
	
	private static final Logger logger = LoggerFactory.getLogger(BankingController.class);	
	private static final String version = "Version: 0.3";
	private static final String project = "Project: Spring Banking Page";
	
	@Autowired
	private AccountsRepository clientsRepository;
	
	@Autowired
	private CurrencyExchange bgnExchange;
	
	@RequestMapping(value = "/", method = RequestMethod.GET)
	public String getBanking(Locale locale, Model model) {
		logger.info("Welcome home! The client locale is {}.", locale);
		
		Date date = new Date();
		DateFormat dateFormat = DateFormat.getDateTimeInstance(DateFormat.LONG, DateFormat.LONG, locale);
		
		String formattedDate = dateFormat.format(date);
		
		model.addAttribute("serverTime", formattedDate );
		model.addAttribute("project", project);
		model.addAttribute("version", version);
						
		return "banking";
	}
	
	@RequestMapping(value = "/", method = RequestMethod.POST)
	public String postBanking(Model model, @ModelAttribute(value = "SpringWeb") InputData input) {
		
		String output = null;
		String userId = input.getClientId();
		String inputUser = input.getClientId();
		
		if (userId == null && inputUser != ""){			
			model.addAttribute("userId", inputUser);
			userId = inputUser;
		}
		
		if (userId != null && !userId.contains(" ")) {
			String action = input.getSelectedOperation();
			String amount = input.getOperationAmount();
			String currency = input.getSelectedCurrency();
			
			if (action != null && action.equals("deposit")){
				output = this.clientsRepository.deposit(userId, amount, currency, bgnExchange);
			} else if (action != null && action.equals("withdraw")){
				output = this.clientsRepository.withdraw(userId, amount, currency, bgnExchange);
			} else {
				output = "Deposit or withdrawal wasn't selected.";
			}
			
			String balance = clientsRepository.getAccountBallance(userId);	
			model.addAttribute("balance", balance);
		} else {
			output = "Enter valid id, no whitespace allowed:";
		}
		
		model.addAttribute("output", output);
		
		return "banking";
	}
}
