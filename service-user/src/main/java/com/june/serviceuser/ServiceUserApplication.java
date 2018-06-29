package com.june.serviceuser;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.EnableEurekaClient;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.logging.Level;
import java.util.logging.Logger;

@SpringBootApplication
@EnableEurekaClient
@RestController
public class ServiceUserApplication {

	private static final Logger LOG = Logger.getLogger(ServiceUserApplication.class.getName());

	public static void main(String[] args) {
		SpringApplication.run(ServiceUserApplication.class, args);
	}

	@Value("${server.port}")
	String port;

	@RequestMapping("/hi")
	public String home(@RequestParam String name){
		LOG.log(Level.INFO, "calling service-user  ");
		return "hi "+ name + ",i'm from port:"+port;
	}
}
