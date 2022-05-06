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

	// Bind axis for MoveZ
	PlayerInputComponent->BindAxis(TEXT("MoveZ"), this, &APCharacter::MoveZ);

	// Bind axis for MoveX
	PlayerInputComponent->BindAxis(TEXT("MoveX"), this, &APCharacter::MoveX);

	// Bind key for sprinting
	PlayerInputComponent->BindAction(TEXT("Sprint"), IE_Pressed, this, &APCharacter::SprintStart);
	PlayerInputComponent->BindAction(TEXT("Sprint"), IE_Released, this, &APCharacter::SprintStop);

	// Bind key for inventory


}

// Move Forward or Backward
void APCharacter::MoveZ(float axis)
{
	if (isBusy)
		return;
	if (!isSprinting)
		axis *= 0.3;
	AddMovementInput(GetActorForwardVector() * axis);
}

// Move to the left or the right
void APCharacter::MoveX(float axis)
{
	if (isBusy)
		return;
	if (!isSprinting)
		axis *= 0.3;
	AddMovementInput(GetActorRightVector() * axis);
}

// Start sprint mode 
void APCharacter::SprintStart()
{
	if (isSprinting != true)
		isSprinting = true;
}

// Stop sprint mode
void APCharacter::SprintStop()
{
	if (isSprinting != false)
		isSprinting = false;
}