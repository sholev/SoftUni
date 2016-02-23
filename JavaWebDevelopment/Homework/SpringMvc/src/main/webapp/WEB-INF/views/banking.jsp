<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta charset="UTF-8">
		<title>Spring banking page</title>
	</head>
	<body>
		<form action="/postBanking" method="POST">
		
			<%=request.getAttribute("output") == null ? "" : request.getAttribute("output") + "<br>"%>
			Client ID: 
			<input type="text" name="userId" value="<%=request.getAttribute("userId") == null ? "" : request.getAttribute("userId")%>">
			<%=request.getAttribute("balance") == null ? "" : "<br>Client balance: " + request.getAttribute("balance") + " BGN"%>
			<br>		
			Operation: 
			<input type="radio" name="action" value="deposit">Deposit
			<input type="radio" name="action" value="withdraw">Withdraw
			<br>
			Amount: <input type="number" name="amount" value="0">
			<select name="currency">
				<option value="usd">USD</option>
				<option value="eur">EUR</option>
				<option value="gbp">GPB</option>
				<option value="bgn">BGN</option>
			</select>
			<input type="submit" value="Submit">	
		</form>
		<br><br>
		<div id="footer">		
		${serverTime}<br>
		${project} <br>
		${version}
		</div>
	</body>
</html>