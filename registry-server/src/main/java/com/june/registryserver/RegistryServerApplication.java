package com.june.registryserver;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import org.springframework.cloud.client.circuitbreaker.EnableCircuitBreaker;

import org.springframework.cloud.netflix.eureka.server.EnableEurekaServer;

import org.springframework.context.annotation.ComponentScan;

@EnableEurekaServer
@SpringBootApplication
@ComponentScan("com.june")

public class RegistryServerApplication {

	public static void main(String[] args) {

		SpringApplication.run(RegistryServerApplication.class, args);

	}
}
