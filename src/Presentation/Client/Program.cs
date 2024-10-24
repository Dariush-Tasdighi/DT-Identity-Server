using System;
using Persistence;
using System.Linq;
using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.Users;
using Domain.Features.Identity.Companies;
using Domain.Features.Identity.Applications;
using Domain.Features.Identity.ApplicationRoles;
using Domain.Features.Identity.UserAccesses;

{
	using var applicationDbContext = new ApplicationDbContext();

	Guid ownerUserId;

	{
		var username = new Username(value: "Dariush");
		var password = new Password(value: "1234512345");
		var emailAddress = new EmailAddress(value: "DariushT@GMail.com");

		var user =
			new User(username: username, password: password, emailAddress: emailAddress);

		applicationDbContext.Add(entity: user);

		await applicationDbContext.SaveChangesAsync();

		ownerUserId = user.Id;
	}

	Guid companyId;

	{
		var companyName = new Name(value: "MyCompany");
		var companyTitle = new Title(value: "My Company");

		var company =
			new Company(userId: ownerUserId, name: companyName, title: companyTitle);

		applicationDbContext.Add(entity: company);

		await applicationDbContext.SaveChangesAsync();

		companyId = company.Id;
	}

	Application application;

	{
		var applicationName = new Name(value: "MyApplication");
		var applicationTitle = new Title(value: "My Application");

		application =
			new Application(companyId: companyId, name: applicationName, title: applicationTitle);

		applicationDbContext.Add(entity: application);

		// نباید دستور ذیل را بنویسیم
		//await applicationDbContext.SaveChangesAsync();
	}

	{
		var userValidIP4_1 = "1.1.1.1";
		var userValidIP4_2 = "2.2.2.2";
		var userValidIP4_3 = "1.1.1.1";

		application.AddUserValidIP(ip: userValidIP4_1);
		application.AddUserValidIP(ip: userValidIP4_2);
		application.AddUserValidIP(ip: userValidIP4_3);
	}

	{
		var applicationValidIP4_1 = "3.3.3.3";
		var applicationValidIP4_2 = "4.4.4.4";
		var applicationValidIP4_3 = "3.3.3.3";

		application.AddApplicationValidIP(ip: applicationValidIP4_1);
		application.AddApplicationValidIP(ip: applicationValidIP4_2);
		application.AddApplicationValidIP(ip: applicationValidIP4_3);
	}

	await applicationDbContext.SaveChangesAsync();

	{
		var applicationRole1 =
			new ApplicationRole(applicationId: application.Id,
			name: new Name(value: "Owner"), code: new Code(10_000),
			title: new Title(value: "Owner"));

		applicationDbContext.Add(entity: applicationRole1);

		var applicationRole2 =
			new ApplicationRole(applicationId: application.Id,
			name: new Name(value: "Programmer"), code: new Code(9_000),
			title: new Title(value: "Programmer"));

		applicationDbContext.Add(entity: applicationRole2);

		var applicationRole3 =
			new ApplicationRole(applicationId: application.Id,
			name: new Name(value: "Administrator"), code: new Code(8_000),
			title: new Title(value: "Administrator"));

		applicationDbContext.Add(entity: applicationRole3);

		await applicationDbContext.SaveChangesAsync();
	}

	Guid simpleUserId;

	{
		var username = new Username(value: "AliReza");
		var password = new Password(value: "1234512345");
		var emailAddress = new EmailAddress(value: "AliReza@GMail.com");

		var user =
			new User(username: username, password: password, emailAddress: emailAddress);

		applicationDbContext.Add(entity: user);

		await applicationDbContext.SaveChangesAsync();

		simpleUserId = user.Id;
	}

	{
		var userAccess =
			new UserAccess(userId: simpleUserId, applicationId: application.Id);

		applicationDbContext.Add(entity: userAccess);

		await applicationDbContext.SaveChangesAsync();
	}
}

{
	using var applicationDbContext = new ApplicationDbContext();

	var username =
		new Username(value: "Dariush");

	var theUser =
		await
		applicationDbContext.Users

		.Include(current => current.Companies)
			.ThenInclude(current => current.Applications)
				.ThenInclude(current => current.UserValidIPs)

		.Include(current => current.Companies)
			.ThenInclude(current => current.Applications)
				.ThenInclude(current => current.ApplicationValidIPs)

		.Where(current => current.Username == username)
		.FirstOrDefaultAsync();

	if (theUser is not null)
	{
		var companyCount =
			theUser.Companies.Count();
	}
}
