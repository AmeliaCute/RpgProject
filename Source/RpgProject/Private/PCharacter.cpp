// Fill out your copyright notice in the Description page of Project Settings.


#include "PCharacter.h"

// Sets default values
APCharacter::APCharacter()
{
 	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void APCharacter::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void APCharacter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

// Called to bind functionality to input
void APCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

	// Bind keybind for MoveZ
	PlayerInputComponent->BindAxis(TEXT("MoveZ"), this, &APCharacter::MoveZ);

	// Bind keybind for MoveX
	PlayerInputComponent->BindAxis(TEXT("MoveX"), this, &APCharacter::AddControllerYawInput);

}

// Move Forward or Backward
void APCharacter::MoveZ(float axis)
{
	AddMovementInput(GetActorForwardVector() * axis);
}

// Move to the left or the right
void APCharacter::MoveX(float axis)
{
	AddMovementInput(GetActorRightVector() * axis);
}

